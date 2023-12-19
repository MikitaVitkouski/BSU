import java.util.Arrays;

public class GroupData {
    private String groupName;
    private String[] teamNames;

    public GroupData(String groupName, String[] teamNames) {
        this.groupName = groupName;
        this.teamNames = teamNames;
    }

    public String getGroupName() {
        return groupName;
    }

    public String[] getTeamNames() {
        return teamNames;
    }

    @Override
    public String toString() {
        return "GroupData{" +
                "groupName='" + groupName + '\'' +
                ", teamNames=" + Arrays.toString(teamNames) +
                '}';
    }
}