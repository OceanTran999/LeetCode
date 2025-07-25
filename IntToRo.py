def addRo(intToRo, mulNum, modulus, dictNum) -> str:
    if(modulus == 0):
        return intToRo
    if(mulNum < 1000):
        if((modulus * mulNum) < (5 * mulNum) and (modulus * mulNum) % (4 * mulNum) == 0 or (modulus * mulNum) % (9 * mulNum) == 0):
            intToRo = dictNum[mulNum] + dictNum[mulNum * (1 + modulus)] + intToRo
        else:
            if(modulus * mulNum >= 5 * mulNum):
                intToRo = dictNum[5 * mulNum] + dictNum[mulNum] * (modulus - 5) + intToRo
            else:
                intToRo = dictNum[mulNum] * modulus + intToRo
    # Because num < 4000
    else:
        if(modulus < 5):
            intToRo = dictNum[1000] * modulus + intToRo
        else:
            intToRo = dictNum[1000] * (modulus - 5) + intToRo
    return intToRo

def intToRoman(num: int) -> str:
        dictNum = {
            1:'I',
            5:'V',
            10:'X',
            50:'L',
            100:'C',
            500:'D',
            1000:'M'
        }
        intToRo = ''
        mulNum = 1
        quotient = num // 10
        modulus = num % 10

        while(mulNum < num):
            if(num < 10):
                break
            intToRo = addRo(intToRo, mulNum, modulus, dictNum)
            modulus = quotient % 10
            mulNum = mulNum * 10
            if(quotient >= 10):        
                # Update values
                quotient = quotient // 10
            else:
                break

        # Final number
        intToRo = addRo(intToRo, mulNum, modulus, dictNum)
        return intToRo

print(intToRoman(100))