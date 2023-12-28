/**
 * @param {number[][]} mat
 * @param {number} k
 * @return {number[]}
 */
var kWeakestRows = function(mat, k) {
    let heap = new minHeap()
    for(let i = 0; i < mat.length; i++) {
        const row = mat[i]
        const soldiers = binarySearch(row)
        heap.insert([soldiers, i], k)
    }
    let res = []
    while(k > 0) {
        res.push(heap.poll())
        k--
    }

    return res.reverse()
};

var binarySearch = function(row) {
    let left = 0, right = row.length - 1, mid = 0;
    while(left <= right) {
        mid = Math.floor((left + right) / 2)
        if(row[mid] === 1) {
            left = mid + 1
        }
        else {
            right = mid - 1 
        }
    }
    return left
}

class minHeap {
    constructor() {
        this.heap = []
    }
    insert(val, k) {
        this.heap.push(val)
        this.heap.sort((a, b) => {
            if(a[0] === b[0]) {
                return a[1] - b[1]
            }
            return a[0] - b[0]
        })
        if(this.heap.length > k) {
            this.heap.pop()
        }
    }
    poll() {
        return this.heap.pop()
    }
}

Input: mat = 
[[1,1,1,1,1],[1,0,0,0,0],[1,1,0,0,0],[1,1,1,1,0],[1,1,1,1,1]],
k = 3

console.log(kWeakestRows(mat, k))
