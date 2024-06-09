def decode(message_file):
    with open(message_file, 'r') as file:
        lines = file.readlines()
        
    number_word_pairs = {}
    for line in lines:
        number, word = line.split()
        number_word_pairs[int(number)] = word

    message_numbers = []
    next_level = 1
    current_level = 0
    for number in sorted(number_word_pairs.keys()):
        current_level += 1
        if current_level == next_level:
            message_numbers.append(number)
            next_level += 1
            current_level = 0

    ans = [number_word_pairs[number] for number in message_numbers]

    return ' '.join(ans)

print(decode("coding_qual_input.txt"))
