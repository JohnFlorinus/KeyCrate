# KeyCrate
A password manager that securely stores the user's credentials in a local CSV database file.
User credentials are encrypted with AES-256 with a key that is derived from the chosen master password via PBKDF2.

Features
* CRUD
* Change Master Password in an already existing database
* Create & Load Backup File

Cryptographic Security
* Bruteforce resistant - The PBKDF2 goes through 1 000 000 iterations with HMAC and SHA512 so that even with the most powerful computer a bruteforce attack would be futile. The application does not force the user to adhere to a certain length or complexity which means that their password may still be cracked if they choose a very weak one.
* Rainbow table attack resistant - Both AES and PBKDF2 uses a unique IV and salt that is randomly generated for each user through a CSPRNG. Trying to crack the master password with precomputed tables will therefore not work.