import uuid
import random
import glob
seedFilenamesList = glob.glob('*.seed.json')
print(seedFilenamesList)
#input file
for seedFile in seedFilenamesList:
  fin = open(seedFile, "rt")
  data = fin.readlines()
  ndata = []
  #output file to write the result to
  #for each line in the input file
  for line in data:
    guid = uuid.uuid4()
    if "Guid.NewGuid()" in line:
      #read replace the string and write to output file
      line = line.replace("Guid.NewGuid()", '"'+str(guid)+'"')
    if "Price" in line:
      pricestr=line.replace('"Price": ','').replace(' ','').replace(',','').replace('\n','')
      pricefloat=float(pricestr)
      randomchange = round(random.uniform(-5,5),2)
      newpricefloat=pricefloat + randomchange
      newpricestr=str(newpricefloat)
      line = line.replace(pricestr, newpricestr)
    ndata.append(line)
  fin.close()
  fout = open(seedFile, "wt")
  fout.writelines(ndata)
  fout.close()
print("DONE!")