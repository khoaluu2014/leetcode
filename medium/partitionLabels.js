/**
 * @param {string} s
 * @return {number[]}
 */
var partitionLabels = function(s) {
    let map = []
    let res = []
    let start = 0
    let end = 0
    
    for(i in s){
        map[s[i]] = i
    }

    for(let i = 0; i < s.length; i++) {
        end = Math.max(end, map[s[i]])
        if(i === end) {
            res.push(i - start + 1)
            start = end + 1
            console.log(res)
        }
    }
    
    return res
};
