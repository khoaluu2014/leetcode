#include <vector>
#include <unordered_map>
#include <iostream>

using namespace std;
class Solution
{
public:
    vector<int> topKFrequent(vector<int> &nums, int k)
    {
        unordered_map<int, int> map;
        vector<vector<int>> heap;
        vector<int> ans;
        if (nums.size() == 1)
        {
            return nums;
        }
        if (nums.size() == 0)
        {
            return {};
        }
        /*
        1: 3
        2: 2
        3: 1
        */
        for (int i : nums)
        {
            map[i]++;
        }
        for (auto &i : map)
        {
            if (heap.size() < k)
            {
                heap.push_back({i.first, i.second});
            }
            else if (i.second > heap[0][1])
            {
                heap[0] = {i.first, i.second};
                minHeapify(heap, 0);
            }
        }
        for (int i = heap.size() - 1; i > -1; i--)
        {
            ans.push_back(heap[i][0]);
        }
        return ans;
    }
    void maxHeapify(vector<vector<int>> &heap, int index)
    {
        int l = 2 * index + 1;
        int r = 2 * index + 2;
        int largest = index;
        if (l < heap.size() and heap[l][1] > heap[largest][1])
        {
            largest = l;
        }
        if (r < heap.size() and heap[r][1] > heap[largest][1])
        {
            largest = r;
        }
        if (largest != index)
        {
            swap(heap[index], heap[largest]);
            maxHeapify(heap, largest);
        }
    }
    void minHeapify(vector<vector<int>> &heap, int index)
    {
        int l = 2 * index + 1;
        int r = 2 * index + 2;
        int smallest = index;
        if (l < heap.size() and heap[l][1] < heap[smallest][1])
        {
            smallest = l;
        }
        if (r < heap.size() and heap[r][1] < heap[smallest][1])
        {
            smallest = r;
        }
        if (smallest != index)
        {
            swap(heap[index], heap[smallest]);
            minHeapify(heap, smallest);
        }
    }
};

int main(int argv, char **argc)
{
    vector<int> nums{1, 1, 1, 2, 2, 3};
    int k = 2;
    Solution sol;
    for (int i : sol.topKFrequent(nums, k))
    {
        cout << i;
    }

    return 0;
}