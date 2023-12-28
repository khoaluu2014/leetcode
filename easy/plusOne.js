/**
 * @param {number[]} digits
 * @return {number[]}
 */
var plusOne = function (digits) {
	let i = digits.length - 1;
	while (i >= 0) {
		if (digits[i] < 9) {
			digits[i] = digits[i] + 1;
			return digits;
		}
		digits[i] = 0;
		i--;
	}

	let newArray = new Array(digits.length + 1).fill(0);
	newArray[0] = 1;

	return newArray;
};

let digits = [4, 3, 2, 1];

console.log(plusOne(digits));
