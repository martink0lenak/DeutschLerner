import json
import io

data = []
def getWord():
    
    
    i = 0
    while True:
        wort = {}
        ge = input("ge: ")
        if ge == "/exit":
            break
        sk = input("sk: ")
        typ = input("type: ")
        gender = input("gender: ") if typ == "n" else "-"
        perfektum = input("perfektum: ") if typ == "v" else "-"
        preateritum = input("präteritum: ") if typ == "v" else "-"
        plural = input("plural: ") if typ == "n" else "-"


            
        confirm = input("Confirm? <RETURN>/N")
        if confirm == "":
            pass
        elif confirm == "N" or confirm == "n":
            continue

        wort["ge"] = ge
        wort["sk"] = sk
        wort["type"] = typ
        wort["gender"] = gender
        wort["perfektum"] = perfektum
        wort["praeteritum"] = preateritum
        wort["plural"] = plural

        data.append(wort)
        i += 1


with io.open(input("File: "), "w", encoding='utf8') as wl:
        
    getWord()
    dct = {"words" : data}
            
    json.dump(dct, wl,indent=2, ensure_ascii=False)
    input()