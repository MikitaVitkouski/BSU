#include <iostream>
#include <vector>
#include <climits>

using namespace std;

int main() {
    int N;
    cin >> N;

    vector<int> A(N + 1);
    vector<int> B(N + 1);

    for (int i = 1; i <= N; i++) {
        cin >> A[i] >> B[i];
    }

    vector<vector<long long>> dp(N + 1, vector<long long>(N + 1, LLONG_MAX));

    for (int i = 1; i <= N; i++) {
        dp[i][i] = 0;
    }

    for (int len = 2; len <= N; len++) {
        for (int i = 1; i <= N - len + 1; i++) {
            int j = i + len - 1;
            for (int k = i; k < j; k++) {
                long long cost = dp[i][k] + dp[k + 1][j] + 1LL * A[i] * B[j];
                dp[i][j] = min(dp[i][j], cost);
            }
        }
    }

    cout << dp[1][N];

    return 0;
}