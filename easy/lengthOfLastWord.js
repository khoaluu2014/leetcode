var lengthOfLastWord = function (s) {
	let i = s.length - 1;
	let lastWordLength = 0;
	while (i >= 0 && (lastWordLength === 0 || s[i] !== " ")) {
		if (s[i] !== " ") {
			lastWordLength++;
		}
		i--;
	}
	return lastWordLength;
};

s = "moon";
console.log(lengthOfLastWord(s));

//lastWordLength !== 0 && s[i] === " "

//lastWordLength === 0 || s[i] !== " "
