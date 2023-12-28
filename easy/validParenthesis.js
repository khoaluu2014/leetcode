/**
 * @param {string} s
 * @return {boolean}
 */
var isValid = function (s) {
  let stack = [];
  let map = new Map();
  map.set("{", "}");
  map.set("(", ")");
  map.set("[", "]");
  for (var i = 0; i < s.length; i++) {
    if (map.has(s[i])) {
      stack.push(map.get(s[i]));
      console.log(stack);
    } else if (!map.has(s[i])) {
      if (stack.pop() !== s[i]) {
        return false;
      }
    }
  }
  return stack.length === 0 ? true : false;
};

s = "()";
console.log(isValid(s));
