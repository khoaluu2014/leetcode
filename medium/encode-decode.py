class Solution:
    """
    @param: strs: a list of strings
    @return: encodes a list of strings to a single string.
    """
    def encode(self, strs):
        # write your code here
        return ':;'.join(strs)
    """
    @param: str: A string
    @return: decodes a single string to a list of strings
    """
    def decode(self, str):
        # write your code here
        decode_string = ":;"
        return str.split(decode_string)


def main():
    sol = Solution()
    strs = ["lint","code","love","you"]
    encode = sol.encode(strs)
    print(encode)

if __name__ == "__main__":
    main()