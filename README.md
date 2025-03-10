 
---

# KML to CSV Converter  

## Opis  
**KML to CSV Converter** to aplikacja Windows Forms umożliwiająca konwersję współrzędnych geograficznych z plików **KML** na format **CSV**. Użytkownik może wybrać, które współrzędne (X, Y, Z) chce eksportować oraz określić format zapisu.  

## Funkcje  
✅ Wczytywanie plików **KML**  
✅ Obsługa formatów **Point** oraz **LineString**  
✅ Możliwość wyboru współrzędnych do eksportu: **X, Y, Z**  
✅ Różne opcje separatorów: **Nowa linia, spacja, przecinek**  
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
Oto dwa przykładowe pliki **KML**, które możesz użyć do testowania aplikacji.  

### **Przykład 1: Punkty (Point)**
```xml
<?xml version="1.0" encoding="UTF-8"?>
<kml xmlns="http://www.opengis.net/kml/2.2">
  <Document>
    <Placemark>
      <name>Punkt 1</name>
      <Point>
        <coordinates>19.944979,50.064650,150</coordinates>
      </Point>
    </Placemark>
    <Placemark>
      <name>Punkt 2</name>
      <Point>
        <coordinates>19.955230,50.067120</coordinates>
      </Point>
    </Placemark>
    <Placemark>
      <name>Punkt 3</name>
      <Point>
        <coordinates>19.968711,50.070678,200</coordinates>
      </Point>
    </Placemark>
  </Document>
</kml>
```
📌 **Zawiera 3 punkty** – jeden z pełnymi współrzędnymi (X, Y, Z), jeden bez wysokości (Z), a jeden z inną wartością wysokości.  

---

### **Przykład 2: Ścieżka (LineString)**
```xml
<?xml version="1.0" encoding="UTF-8"?>
<kml xmlns="http://www.opengis.net/kml/2.2">
  <Document>
    <Placemark>
      <name>Trasa testowa</name>
      <LineString>
        <coordinates>
          19.944979,50.064650,100
          19.955230,50.067120,120
          19.968711,50.070678
          19.982101,50.073800,140
          19.995564,50.075950
          20.009018,50.078230,160
          20.022473,50.080500
        </coordinates>
      </LineString>
    </Placemark>
  </Document>
</kml>
```
📌 **Zawiera ścieżkę (LineString)** – niektóre punkty mają współrzędną Z (wysokość), a inne nie.  

Oba pliki pozwolą sprawdzić, czy program poprawnie obsługuje różne formaty współrzędnych. 🚀

## Autor  
📌 **Neteno**  
