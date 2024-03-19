19 lines (13 sloc)  877 Bytes


[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

## MARCATEMPO
Webapp che si propone di aiutare e digitalizzare le piccole aziende artigiane italiane, con un marcatempo a prezzi ridotti o quasi nulli.<br/>
Questo applicativo aiuta la gestione del personale formato da pochi elementi. <br/>
Il progetto permette tramite la generazione e la lettura di un Qrcode di memorizzare entrata l'uscita dei dipendenti<br/>

### Realizzato con
* Asp.net Core
* Vue
### Versioni:
Sono presenti due versioni:<br>
1. [Nel ramo main](https://github.com/0d1n92/marcatempo/tree/main) la versione docker con l'integrazione del tool compose
2. [Nel ramo main-k8s](https://github.com/0d1n92/marcatempo/tree/main-k8s) la versione kubernetes


[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/enrico-rombaldoni-695189208/
[license-url]: https://github.com/0d1n92/marcatempo/blob/main/LICENSE


## Primo avvio

1. Rinominare file .env.example in file .env
2. Se si nessita di lanciare la migrations nel file .env passare MIGRATION a true, verrà creato solo l'utente administator con pswd qwerty, si prega di cambiarla in un secondo momento

## configurazione stmp

la configurazione stmp si trova nella appsettings.*.json