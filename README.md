# KeyCrate
A password manager that uses cryptographically secure algorithms to store user credentials.
User credentials are encrypted with AES-256 and stored in a local CSV database.
The decryption key is derived from the master password via PBKDF2, PBKDF2 goes through 1 000 000 iterations with SHA512 and HMAC.
Both AES and PBKDF2 uses a unique salt and IV generated for each user through a CSPRNG making the encryption resistant to rainbow table attacks.

The password manager offers CRUD capabilities and a way for the user to change their master password in an already existing database but other than this it offers no extra features.