var addBinary = function (a, b) {
	let bLen = b.length - 1;
	let aLen = a.length - 1;
	var carry = 0;

	let result = "";

	while (aLen >= 0 || bLen >= 0 || carry === 1) {
		let sum = carry;

		if (aLen >= 0) {
			sum += parseInt(a[aLen], 2);
			aLen--;
		}
		if (bLen >= 0) {
			sum += parseInt(b[bLen], 2);
			bLen--;
		}
		carry = sum > 1 ? 1 : 0;
		result = (sum % 2).toString() + result;
	}
	return result;
};

let a = "1010",
	b = "1011";

console.log(addBinary(a, b));
