# KeyCrate
A password manager that securely stores the user's credentials in a local CSV database file.
User credentials are encrypted with AES-256 with a key that is derived from the chosen master password via PBKDF2.

Features
* CRUD
* Change Master Password in an already existing database
* Create & Load Backup File

Cryptographic Security
* Bruteforce resistant - The PBKDF2 goes through 1 000 000 iterations with HMAC and SHA512.
* Precomputed tables resistant - Both AES and PBKDF2 uses a unique IV and salt that is randomly generated for each user through a CSPRNG. Rainbow table attacks will not work.
