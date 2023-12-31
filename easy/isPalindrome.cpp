#include <string>
#include <cctype>
#include <iostream>

using namespace std;

class Solution {
    public:
        bool isPalindrome(string s) {
            int i = 0, j = s.size() - 1;
            while(i < j) {
                while(i < j && !isalpha(s[i]) && !isdigit(s[i])) {
                    i++;
                }
                while(i < j && !isalpha(s[j]) && !isdigit(s[j])) {
                    j--;
                }
                if(tolower(s[i]) != tolower(s[j])) {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
};

int main(int argc, char **argv) {
    Solution sol;

    string s = "A man, a plan, a canal: Panama";
    cout << sol.isPalindrome(s);
    return 0;
}

