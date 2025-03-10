Oto plik **README.md** do Twojego projektu:  

---

# KML to CSV Converter  

## Opis  
**KML to CSV Converter** to aplikacja Windows Forms umożliwiająca konwersję współrzędnych geograficznych z plików **KML** na format **CSV**. Użytkownik może wybrać, które współrzędne (X, Y, Z) chce eksportować oraz określić format zapisu.  

## Funkcje  
✅ Wczytywanie plików **KML**  
✅ Obsługa formatów **Point** oraz **LineString**  
✅ Możliwość wyboru współrzędnych do eksportu: **X, Y, Z**  
✅ Różne opcje separatorów: **Nowa linia, spacja, przecinek, średnik, pionowa kreska, tabulator**  
✅ Obsługa nawiasów w eksporcie **(np. [], {}, ())**  
✅ Ignorowanie pustych wpisów (nie zapisuje `[]` w CSV)  
✅ Informacja o błędach w osobnym oknie  

## Wymagania  
🔹 **.NET Framework 4.7.2** lub nowszy  
🔹 System **Windows 7/10/11**  

## Instalacja i użytkowanie  
1️⃣ **Pobierz** i uruchom aplikację.  
2️⃣ **Wybierz plik** KML za pomocą przycisku **"Wybierz plik"**.  
3️⃣ **Wybierz opcje eksportu**:  
   - Separator wartości  
   - Format nawiasów  
   - Współrzędne do zapisania (X, Y, Z)  
4️⃣ **Kliknij "Konwertuj"**, aby zapisać plik jako **CSV**.  
5️⃣ Plik CSV zostanie zapisany w tej samej lokalizacji co plik KML.  

## Obsługa błędów  
⚠ Jeśli plik KML zawiera błędne dane (np. brak współrzędnych), pojawi się **ostrzeżenie**.  
⚠ Jeśli format pliku jest nieprawidłowy, program poinformuje o błędzie w **oknie dialogowym** i nie zawiesi się.  

## Przykładowy plik KML  
```xml
<?xml version="1.0" encoding="UTF-8"?>
<kml xmlns="http://www.opengis.net/kml/2.2">
  <Document>
    <Placemark>
      <name>Przykładowy Punkt</name>
      <Point>
        <coordinates>19.944979,50.064650,0</coordinates>
      </Point>
    </Placemark>
  </Document>
</kml>
```

## Autor  
📌 **Neteno**  
