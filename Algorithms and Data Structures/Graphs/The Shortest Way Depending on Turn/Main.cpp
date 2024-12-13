#include <fstream>
#include <vector>
#include <queue>

using namespace std;

#define LL long long int

struct Point {
    int x;
    int y;

    Point() : x(0), y(0) {}
    Point(int _x, int _y) : x(_x), y(_y) {}
};

int orientation(Point a, Point b, Point c) {
    if (a.x == c.x && a.y == c.y) return 1;

    if (a.x == b.x && a.y == b.y) {
        Point pointAhead(a.x, a.y - 1);
        int crossProduct = (pointAhead.x * a.y + a.x * c.y + pointAhead.y * c.x) - (c.x * a.y + c.y * pointAhead.x + pointAhead.y * a.x);
        return (crossProduct > 0) ? 2 : 0;
    }

    int crossProduct = (a.x * b.y + a.y * c.x + b.x * c.y) - (c.x * b.y + b.x * a.y + c.y * a.x);
    return (crossProduct > 0) ? 3 : 0;
}

void printResult(ofstream& out, bool success, LL distance) {
    if (success) {
        out << "Yes\n" << distance;
    }
    else {
        out << "No";
    }
    out << endl;
}

int main() {
    ifstream in("input.txt");
    ofstream out("output.txt");

    int N = 0;
    int M = 0;
    int K = 0;
    in >> N >> M >> K;

    int x = 0, y = 0;

    vector<vector<int>> graph(N);
    vector<Point> coordinates(N);

    for (int i = 0; i < N; i++) {
        graph[i].resize(N, -1);
        in >> x >> y;
        coordinates[i] = Point(x, y);
    }

    int p = 0, r = 0, t = 0;

    vector<int> intersection(N);

    for (int i = 0; i < M; i++) {
        in >> p >> r >> t;
        p--; r--;
        graph[p][r] = graph[r][p] = t;
        intersection[p]++, intersection[r]++;
    }

    int A = 0;
    int B = 0;

    in >> A >> B;
    A--;
    B--;

    priority_queue<pair<LL, pair<int, int>>> heap;
    heap.push({ 0, {A, A} });

    pair<LL, pair<int, int>> GraphNodeInfo;

    while (!heap.empty()) {
        while (!heap.empty()) {
            GraphNodeInfo = heap.top();
            heap.pop();
            int& currentGraphValue = graph[GraphNodeInfo.second.first][GraphNodeInfo.second.second];
            if (currentGraphValue != -1) {
                currentGraphValue = -1;
                break;
            }
        }

        if (GraphNodeInfo.second.second == B) {
            printResult(out, true, -GraphNodeInfo.first);
            return 0;
        }

        for (int i = 0; i < N; i++) {
            if (graph[GraphNodeInfo.second.second][i] == -1)
                continue;

            int currentVertex = GraphNodeInfo.second.second;
            int nextVertex = i;

            LL way = -GraphNodeInfo.first + graph[currentVertex][nextVertex];
            int tmp = orientation(coordinates[GraphNodeInfo.second.first], coordinates[currentVertex], coordinates[nextVertex]);

            if (tmp != 0) {
                LL additionalCost = (tmp == 1 || tmp == 3) ? K * intersection[currentVertex] : (tmp == 2) ? K * intersection[GraphNodeInfo.second.first] : 0;
                way += additionalCost;
            }

            heap.push({ -way, {currentVertex, nextVertex} });
        }
    }

    out << "No" << endl;
    return 0;
}