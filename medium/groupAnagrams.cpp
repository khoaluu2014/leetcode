#include <algorithm>
#include <iostream>
#include <string>
#include <unordered_map>
#include <vector>

using namespace std;

class Solution {
public:
  vector<vector<string>> groupAnagrams(vector<string> &strs) {
    vector<vector<string>> res;
    vector<string> strs_sorted;
    vector<string> group;
    unordered_map<string, vector<string>> freqMap;
    if (strs.size() == 0) {
      return {{}};
    }
    if (strs.size() == 1) {
      res.push_back(strs);
      return res;
    }
    // Iterate each string in vector/array
    for (string s : strs) {
      sort(s.begin(), s.end());
      strs_sorted.push_back(s);
    }
    for (int i = 0; i < strs.size(); i++) {
      freqMap[strs_sorted[i]].push_back(strs[i]);
    }
    for (const pair<const string, vector<string>> &itr : freqMap) {
      res.push_back(itr.second);
    }
    return res;
  }
};

int main(int argv, char **argc) {
  vector<string> strs{"eat", "tea", "tan", "ate", "nat", "bat"};
  vector<string> strs1{};
  vector<string> strs2{{"a"}};

  Solution sol;
  for (auto i : sol.groupAnagrams(strs)) {
    for (auto j : i) {
      cout << j;
    }
  }
}
