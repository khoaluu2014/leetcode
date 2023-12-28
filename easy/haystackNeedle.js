/**
 * @param {string} haystack
 * @param {string} needle
 * @return {number}
 */
var strStr = function (haystack, needle) {
	let needleStart = 0;
	let needleEnd = needle.length;

	for (let i = 0; i < haystack.length - needle.length + 1; i++) {
		if (haystack.substring(i, i + needleEnd) === needle) {
			return i;
		}
	}

	return -1;
};

let haystack = "butsad",
	needle = "sad";

console.log(strStr(haystack, needle));
