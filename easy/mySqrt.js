/**
 * @param {number} x
 * @return {number}
 */
var mySqrt = function (x) {
	if (x < 2) {
		return x;
	}

	let left = 1;
	let right = Math.floor(x / 2);

	while (left <= right) {
		const mid = Math.floor(left + (right - left) / 2);
		const squared = mid * mid;

		if (squared === x) {
			return mid;
		} else if (squared < x) {
			left = mid + 1;
		} else if (squared > x) {
			right = mid - 1;
		}
	}
	return right;
};

let x = 8;
console.log(mySqrt(x));
