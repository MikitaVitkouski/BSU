/*Витковский Никита Фёдорович 2 курс 5 группа 19/12/2023

 я не ввожу значения с клавитару с N,M,K, Count. код воспринимает информацию из файлов нормально!!! может быть разное количество команд в группе.
итоговый файл с Results.txt работает некорректно и выводит лишь информацию о последней группе, нужно доработать, GroupsOut.txt - всё верно*/

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.ArrayList;
import java.util.Map;
import java.util.HashMap;

public class Main {
    public static void main(String[] args) {
        try {
            GroupData[] groupData = readGroups("Groups.txt");
            ClassBD[] groupsBDs = initializeGroups(groupData);

            processMatches(groupsBDs, "Game.txt");
            writeResults(groupsBDs, "GroupsOut.txt");

            for(ClassBD classBD: groupsBDs) {
                classBD.writeOverallResults("Results.txt");
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static GroupData[] readGroups(String filePath) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader(filePath));
        List<GroupData> groupsList = new ArrayList<>();

        String line;
        while ((line = reader.readLine()) != null) {
            String[] groupData = line.split("\\s+");
            String groupName = groupData[0];
            String[] teamNames = Arrays.copyOfRange(groupData, 1, groupData.length);

            groupsList.add(new GroupData(groupName, teamNames));
        }

        reader.close();

        return groupsList.toArray(new GroupData[0]);
    }

    private static ClassBD[] initializeGroups(GroupData[] groupData) {
        ClassBD[] groupsBDs = new ClassBD[groupData.length];
        Map<String, Team> allTeams = new HashMap<>();

        for (int i = 0; i < groupData.length; i++) {
            GroupData data = groupData[i];
            ClassBD classBD = new ClassBD(Arrays.asList(data));

            for (String teamName : data.getTeamNames()) {
                Team team = allTeams.computeIfAbsent(teamName, Team::new);
                classBD.getTeams().put(teamName, new Team(teamName));
            }

            groupsBDs[i] = classBD;
        }

        return groupsBDs;
    }

    private static void processMatches(ClassBD[] groupsBDs, String filePath) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader(filePath));

        String line;
        while ((line = reader.readLine()) != null) {
            String[] matchData = line.split("\\s+|:");

            String team1Name = matchData[0];
            int scoreTeam1 = Integer.parseInt(matchData[1]);
            int scoreTeam2 = Integer.parseInt(matchData[2]);
            String team2Name = matchData[3];

            Match match = new Match(team1Name, team2Name, scoreTeam1, scoreTeam2);

            for (ClassBD classBD : groupsBDs) {
                classBD.processMatches(classBD, new Match[]{match});
            }
        }

        reader.close();
    }

    private static void writeResults(ClassBD[] groupsBDs, String filePath) throws IOException {
        FileWriter writer = new FileWriter(filePath);

        for (ClassBD classBD : groupsBDs) {
            writer.write(classBD.toString());
        }

        writer.close();
    }
}