#include <iostream>
#include <vector>
#include <queue>
#include <climits>
#include <fstream>


// structure describing an edge in the graph
struct Rebro {
    int kuda; // destination vertex
    int obratno; // index of reverse edge
    int propusk; // capacity of the edge
};

// class which has the Edmonds-Karp max flow algorithm
class MaksPotok {
private:
    int kolvo_vershin_; // number of vertices
    std::vector<std::vector<Rebro>> graf_; // adjacency list

    // BFS
    bool poisk_v_shirinu(int istochnik, int stok,
        std::vector<int>& roditel_vershina,
        std::vector<int>& roditel_rebro) {
        std::fill(roditel_vershina.begin(), roditel_vershina.end(), -1);
        std::queue<int> ochered;
        ochered.push(istochnik);
        roditel_vershina[istochnik] = istochnik;

        while (!ochered.empty()) {
            int v = ochered.front();
            ochered.pop();

            for (size_t i = 0; i < graf_[v].size(); ++i) {
                Rebro& r = graf_[v][i];
                if (r.propusk > 0 && roditel_vershina[r.kuda] == -1) {
                    roditel_vershina[r.kuda] = v;
                    roditel_rebro[r.kuda] = static_cast<int>(i);
                    if (r.kuda == stok)
                        return true; // path to sink found
                    ochered.push(r.kuda);
                }
            }
        }
        return false; // no path found
    }
public:
    explicit MaksPotok(int kolvo_vershin)
        : kolvo_vershin_(kolvo_vershin), graf_(kolvo_vershin) {
    }

    // add directed edge with capacity (1 or INF)
    void dobavit_rebro(int otkuda, int kuda, int propusk) {
        Rebro pryamoe{ kuda, static_cast<int>(graf_[kuda].size()), propusk };
        Rebro obratnoe{ otkuda, static_cast<int>(graf_[otkuda].size()), 0 };
        graf_[otkuda].push_back(pryamoe);
        graf_[kuda].push_back(obratnoe);
    }

    // the Edmonds-Karp max flow algorithm
    int maks_potok(int istochnik, int stok) {
        int tekushiy_potok{ 0 };
        std::vector<int> roditel_vershina(kolvo_vershin_);
        std::vector<int> roditel_rebro(kolvo_vershin_);

        // while augmenting path exists
        while (poisk_v_shirinu(istochnik, stok, roditel_vershina, roditel_rebro)) {
            int dobavka{ INT_MAX };

            // 1. find minimum capacity on the path
            for (int v = stok; v != istochnik; v = roditel_vershina[v]) {
                int u = roditel_vershina[v];
                Rebro& r = graf_[u][roditel_rebro[v]];
                dobavka = std::min(dobavka, r.propusk);
            }

            // 2. update residual capacities along the path
            for (int v = stok; v != istochnik; v = roditel_vershina[v]) {
                int u = roditel_vershina[v];
                Rebro& r = graf_[u][roditel_rebro[v]];
                r.propusk -= dobavka;
                graf_[r.kuda][r.obratno].propusk += dobavka;
            }

            // add to total_flow
            tekushiy_potok += dobavka;
        }

        return tekushiy_potok;
    }
};

int main() {
    std::setlocale(LC_ALL, "Russian");

    std::ifstream in("input.txt");
    std::ofstream out("output.txt");

    if (!in.is_open() || !out.is_open()) {
        std::cerr << "Can't open input files\n";
        return 1;
    }

    int kol_vo_komnat{}, kol_vo_vhodov{}, kol_vo_vyhodov{};
    in >> kol_vo_komnat >> kol_vo_vhodov >> kol_vo_vyhodov;

    // read adjacency matrix C
    std::vector<std::vector<int>> C(kol_vo_komnat, std::vector<int>(kol_vo_komnat));
    for (int i = 0; i < kol_vo_komnat; ++i)
        for (int j = 0; j < kol_vo_komnat; ++j)
            in >> C[i][j];

    // read input (entrances) and output (exits) nodes
    std::vector<int> vhody(kol_vo_vhodov), vyhody(kol_vo_vyhodov);
    for (int i = 0; i < kol_vo_vhodov; ++i) {
        in >> vhody[i];
        --vhody[i];
    }
    for (int i = 0; i < kol_vo_vyhodov; ++i) {
        in >> vyhody[i];
        --vyhody[i];
    }

    // source, sink nodes
    const int istochnik = kol_vo_komnat;
    const int stok = kol_vo_komnat + 1;
    const int INF = 1000000000;

    MaksPotok potok(kol_vo_komnat + 2);

    // 1. add edges between rooms with capacity = 1
    for (int i = 0; i < kol_vo_komnat; ++i)
        for (int j = 0; j < kol_vo_komnat; ++j)
            if (C[i][j] == 1)
                potok.dobavit_rebro(i, j, 1);

    // 2. connect all sources to all entrances
    for (int x : vhody)
        potok.dobavit_rebro(istochnik, x, INF);

    // 3. connect all sinks to sink
    for (int y : vyhody)
        potok.dobavit_rebro(y, stok, INF);

    // 4. compute max flow
    int rezultat = potok.maks_potok(istochnik, stok);

    out << rezultat << "\n";

    return 0;
}