var longestCommonPrefix = function(strs) {
    if(strs.length < 1) {
        return "";
    }
    
    var commonPrefix = strs[0];

    for(let i = 1; i < strs.length; i++) {
        let currentWord = strs[i];
        let j = 0;
        while(j < currentWord.length && commonPrefix[j] === currentWord[j]) {
            j++
        }
       
        commonPrefix = commonPrefix.substring(0, j)
        

    }
    return commonPrefix
}

strs = ["flower","flow","flight"]


console.log(longestCommonPrefix(strs))

strs = ["dog","racecar","car"]
console.log(longestCommonPrefix(strs))