# EncryptedAuctionDotNet
is a dotnet core based solution demonstrating the usage of LSH algorithm in a centralized search system.  
The basic principle of the system is that a central service can run search queries on the products of many different _stores_ _products_ and provide the _client_ with the best matches without keeping track of the _products_ being provided by stores or searched by clients. This is achieved by only keeping a hashed (using lsh) version of the products and providing the search terms in the same hashed format.


## Setup
Start with cloning the repo. All commands are meant to be run from the repositories root folder.

### With Docker
#### Tested with:
 * docker v19.03.13
 * docker-compose v1.27.4

### Configuration
Edit the json files in [configs](configs) folder.

### Running
To run the __services__:  
Run on console  
```docker-compose up --build```  
To run the __client__:  
Download the latest [release](https://github.com/KostasAronis/EncryptedAuctionDotNet/releases).  
Extract the appropriate version for your platform windows x86 or windows x64.  
Edit EncryptedAuctionClient.dll.config if configuration is needed (mainly aggregator url).  
Run EncryptedAuctionClient.exe  

## License
[GNU GENERAL PUBLIC LICENSE](LICENSE)

## Contributing
Contributing is not currently possible as this project is meant to be my master's thesis.



/*
 * Eisagwgh
 *1 Thewria lsh
 *2 to provlhma kai pws to lunw arxitektonika
 ** diagrama use case + sequence?
 *3 stoixeia ulopoihshs (upokefalaio ergaleia)
 ** kapoiou eidous class diagram?
 *4 paradeigma ekteleshs
 *5 epilogos mellontikes epektaseis 
 * 
 * video => paradeigma
 * 

TODO:
* LSH IN DATABASE
* AUTHENTICATION ETC TO BECOME A REAL APP
* REVERSE HASHING ON STORE LEVEL TO SEE IF AGGREGATOR CHANGED SOMETHING


*/