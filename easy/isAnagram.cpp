#include <string>
#include <unordered_map>
#include <iostream>

using namespace std;

class Solution {
public:
    bool isAnagram(string s, string t) {
        if(s.size() != t.size()) return false;

        unordered_map<char, int> map;
        for(char c : s) {
            map[c]++;
        }
        for(char c : t) {
            if(--map[c] < 0) {
                return false;
            
            }
        }
        return true;
    }
};

int main(int argc, char** argv) {
    Solution s;
    cout << s.isAnagram("anagram", "nagaram");
    return 0;
}