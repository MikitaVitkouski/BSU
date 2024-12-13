public class Team {
    private String name;
    private int points;
    private int wins;
    private int draws;
    private int losses;
    private int goalsScored;
    private int goalsConceded;
    private int gamesPlayed;

    public Team(String name) {
        this.name = name;
    }

    public void updateStats(int points, int goalsScored, int goalsConceded) {
        this.points += points;
        this.goalsScored += goalsScored;
        this.goalsConceded += goalsConceded;
        this.gamesPlayed++;
        if (points == 3) {
            this.wins++;
        } else if (points == 2) {
            this.draws++;
        } else if (points == 1) {
            this.losses++;
        }
    }

    public String getName() {
        return name;
    }

    public int getPoints() {
        return points;
    }

    public int getWins() {
        return wins;
    }

    public int getDraws() {
        return draws;
    }

    public int getLosses() {
        return losses;
    }

    public int getGoalsScored() {
        return goalsScored;
    }

    public int getGoalsConceded() {
        return goalsConceded;
    }

    public int getGamesPlayed() {
        return gamesPlayed;
    }
}
