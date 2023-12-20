import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.List;
import java.util.stream.Collectors;
import java.util.Comparator;
import java.util.ArrayList;
import java.io.*;

public class ClassBD implements InterfBD {
    private Map<String, Team> teams;
    private List<GroupData> groupDataList;

    public ClassBD(List<GroupData> groupDataList) {
        this.groupDataList = groupDataList;
        this.teams = new HashMap<>();
    }

    public Map<String, Team> getTeams() {
        return teams;
    }

    private String getGroupByTeamName(String teamName) {
        for (GroupData groupData : groupDataList) {
            if (Arrays.asList(groupData.getTeamNames()).contains(teamName)) {
                return groupData.getGroupName();
            }
        }
        return null;
    }

    @Override
    public void processMatches(ClassBD classBD, Match[] matches) {
        for (Match match : matches) {
            String team1Name = match.getTeam1();
            String team2Name = match.getTeam2();

            String group1 = getGroupByTeamName(team1Name);
            String group2 = getGroupByTeamName(team2Name);

            if (group1 != null && group1.equals(group2)) {
                Team team1 = classBD.getTeams().computeIfAbsent(team1Name, Team::new);
                Team team2 = classBD.getTeams().computeIfAbsent(team2Name, Team::new);

                int pointsTeam1;
                int pointsTeam2;

                if (match.getScoreTeam1() > match.getScoreTeam2()) {
                    pointsTeam1 = 3;
                    pointsTeam2 = 1;
                } else if (match.getScoreTeam1() < match.getScoreTeam2()) {
                    pointsTeam1 = 1;
                    pointsTeam2 = 3;
                } else {
                    pointsTeam1 = 2;
                    pointsTeam2 = 2;
                }

                team1.updateStats(pointsTeam1, match.getScoreTeam1(), match.getScoreTeam2());
                team2.updateStats(pointsTeam2, match.getScoreTeam2(), match.getScoreTeam1());
            }
        }
    }

    public List<Team> getAllTeamsInGroup() {
        return teams.values().stream()
                .filter(team -> team.getGamesPlayed() > 0)
                .sorted(Comparator.comparingInt(Team::getPoints)
                        .reversed()
                        .thenComparing(Comparator.comparingInt(Team::getGamesPlayed))
                )
                .collect(Collectors.toList());
    }

    public void writeOverallResults(String filePath, List<ClassBD> allGroups) throws IOException {
        FileWriter writer = new FileWriter(filePath);

        List<Team> allTeams = new ArrayList<>();
        for (ClassBD classBD : allGroups) {
            allTeams.addAll(classBD.getAllTeamsInGroup());
        }

        allTeams.sort(Comparator.comparingInt(Team::getPoints)
                .reversed()
                .thenComparing(Comparator.comparingInt(Team::getGamesPlayed))
        );

        for (Team team : allTeams) {
            writer.write(team.getName() + " " +
                    team.getPoints() + " " +
                    team.getGamesPlayed() + "\n");
        }

        writer.close();
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();

        for (GroupData groupData : groupDataList) {
            result.append("Group ").append(groupData.getGroupName()).append(":\n");

            List<Team> sortedTeams = Arrays.stream(groupData.getTeamNames())
                    .map(teams::get)
                    .sorted(Comparator.comparingInt(Team::getPoints)
                            .reversed()
                            .thenComparing(team -> team.getGoalsScored() - team.getGoalsConceded())
                            .thenComparingInt(Team::getGoalsScored))
                    .collect(Collectors.toList());

            for (Team team : sortedTeams) {
                result.append(team.getName()).append(" ")
                        .append(team.getPoints()).append(" ")
                        .append(team.getWins()).append(" ")
                        .append(team.getDraws()).append(" ")
                        .append(team.getLosses()).append(" ")
                        .append(team.getGoalsScored()).append(" ")
                        .append(team.getGoalsConceded()).append("\n");
            }
        }

        return result.toString();
    }
}
