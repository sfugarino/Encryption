# Encryption

To encrypt the input text

encrypt [-s|--shift] "Shift" "Input Text"

[-s|--shift]   Optional. The number charachters to shift. Can be negative. If shift is not specified the application will out put encrypted text for shift values 0-26. 

Input Text     Required. The text which has to be processed

To decrypt the input text

dencrypt [-s|--shift] "Shift" "Input Text"

[-s|--shift]   Optional. The number charachters to shift. Can be negative. If shift is not specified the application will out put decrypted text for shift values 0-26.

Input Text     Required. The text which has to be processed

Assumptions:

1. Only letters are encrypted
2. Case is preserved (probably shouldn't be)
