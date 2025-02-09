# Weather Data Console Application

## **Beskrivelse**
Dette programmet henter værdata (temperatur og vindhastighet) for en spesifisert by (Haugesund) fra **WeatherAPI** og skriver det ut til konsollen. Programmet oppdaterer informasjonen hvert 10. sekund og er skrevet i C#.

---

## **Krav**
- **Utviklingsmiljø**:Visual Studio Code
- **.NET versjon**: 6.0 eller høyere.
- **Eksterne biblioteker**:  
  - `Newtonsoft.Json` (for parsing av JSON-data).

---

## **Installasjon**
1. **Klon prosjektet**:  
   Kopier programmet til ønsket katalog.

2. **Installer nødvendige avhengigheter**:  
   Åpne terminal i prosjektmappen og kjør følgende kommando:  
   ```bash
   dotnet add package Newtonsoft.Json
   ```

3. **Sett opp API-nøkkel**:  
   - Gå til [WeatherAPI](https://www.weatherapi.com/) og opprett en gratis konto for å få API-nøkkelen din.
   - Åpne kildekoden og erstatt `5fb4bae3c1b740bb986123429252401` med din egen API-nøkkel:
     ```csharp
     private const string ApiKey = "DIN_API_NØKKEL";
     ```

4. **Kjør programmet**:  
   - Åpne terminal i prosjektmappen og kjør:
     ```bash
     dotnet run
     ```

---

## **Bruk**
- Programmet henter værdata for Haugesund og skriver følgende informasjon til konsollen:
  - Temperatur (i Celsius).
  - Vindhastighet (i meter per sekund).
  - Tidspunkt for siste oppdatering.

- Informasjonen oppdateres automatisk hvert 10. sekund.

---

## **Feilsøking**
1. **Feil: "Kunne ikke hente data"**:
   - Sjekk om API-nøkkelen er riktig og gyldig.
   - Sørg for at datamaskinen har internettforbindelse.

2. **Feil: "Uventet JSON-format"**:
   - Sjekk om API-responsen er gyldig ved å åpne URL-en i en nettleser:
     ```
     https://api.weatherapi.com/v1/current.json?key=DIN_API_NØKKEL&q=Haugesund&aqi=no
     ```

3. **JSON-parsing-feil**:
   - Sørg for at `Newtonsoft.Json`-biblioteket er riktig installert.
   - Installer på nytt ved behov:
     ```bash
     dotnet add package Newtonsoft.Json
     ```