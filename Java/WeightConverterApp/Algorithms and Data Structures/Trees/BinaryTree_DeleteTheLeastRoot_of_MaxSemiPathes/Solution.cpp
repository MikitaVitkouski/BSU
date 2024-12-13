#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>

#define LL long long

struct TreeNode {
    LL key;
    TreeNode* left;
    TreeNode* right;

    TreeNode(LL val) : key(val), left(nullptr), right(nullptr) {}
};

TreeNode* insert(TreeNode* root, LL key) {
    if (!root) {
        return new TreeNode(key);
    }
    if (key < root->key) {
        root->left = insert(root->left, key);
    }
    else if (key > root->key) {
        root->right = insert(root->right, key);
    }
    return root;
}

void preLeft(TreeNode* root, std::ofstream& outputFile) {
    if (root) {
        outputFile << root->key << "\n";
        preLeft(root->left, outputFile);
        preLeft(root->right, outputFile);
    }
}

int height(TreeNode* node) {
    if (!node)
        return 0;

    int leftHeight = height(node->left);
    int rightHeight = height(node->right);

    return std::max(leftHeight, rightHeight) + 1;
}

TreeNode* findMin(TreeNode* node) {
    while (node && node->left) {
        node = node->left;
    }
    return node;
}

int findMaxSemipathsHelper(TreeNode* node, std::vector<TreeNode*>& maxSemipathRoots, LL& maxLength);

TreeNode* RightRemove(TreeNode* root, LL key) {
    if (root == nullptr) {
        return root;
    }
    if (key < root->key) {
        root->left = RightRemove(root->left, key);
    }
    else if (key > root->key) {
        root->right = RightRemove(root->right, key);
    }
    else {
        if (root->left == nullptr) {
            TreeNode* temp = root->right;
            delete root;
            return temp;
        }
        else if (root->right == nullptr) {
            TreeNode* temp = root->left;
            delete root;
            return temp;
        }
        TreeNode* temp = findMin(root->right);
        root->key = temp->key;
        root->right = RightRemove(root->right, temp->key);
    }
    return root;
}

std::vector<TreeNode*> findMaxSemipaths(TreeNode* root, LL& maxLength) {
    std::vector<TreeNode*> maxSemipathRoots;
    maxLength = 0;
    findMaxSemipathsHelper(root, maxSemipathRoots, maxLength);
    return maxSemipathRoots;
}

int findMaxSemipathsHelper(TreeNode* node, std::vector<TreeNode*>& maxSemipathRoots, LL& maxLength) {
    if (!node) return 0;

    LL leftHeight = findMaxSemipathsHelper(node->left, maxSemipathRoots, maxLength);
    LL rightHeight = findMaxSemipathsHelper(node->right, maxSemipathRoots, maxLength);

    LL sum = leftHeight + rightHeight + 1;

    if (sum > maxLength) {
        maxLength = sum;
        maxSemipathRoots.clear();
        maxSemipathRoots.push_back(node);
    }
    else if (sum == maxLength) {
        maxSemipathRoots.push_back(node);
    }

    return std::max(leftHeight, rightHeight) + 1;
}

int main() {
    std::ifstream in("input.txt");

    TreeNode* root = nullptr;
    LL key = 0;

    while (in >> key) {
        root = insert(root, key);
    }

    LL maxLength = 0;
    std::vector<TreeNode*> maxSemipathRoots = findMaxSemipaths(root, maxLength);

    std::vector<LL> roots{};

    for (auto i : maxSemipathRoots) {
        roots.push_back(i->key);
    }

    std::sort(roots.begin(), roots.end());

    LL keyToDelete = roots[0];

    root = RightRemove(root, keyToDelete);

    std::ofstream out("output.txt");
    preLeft(root, out);

    return 0;
}