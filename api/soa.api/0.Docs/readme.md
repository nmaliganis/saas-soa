
Base URL
Το REST API θα είναι διαθέσιμο στο ακόλουθο base URL για όλες τις εργασίες:
https://localhost:8765/evcharge/api
Τα επιμέρους Resources (REST endpoints) που θα διατίθενται μέσω του API θα είναι προσβάσιμα μέσω
του παραπάνω base URL, ως εξής:
{baseURL}/{service}/{path-to-resource}
Όπου {service} μία από τις υπηρεσίες που θα διατίθεται, όπως αναφέρονται παρακάτω:
Για παράδειγμα, το endpoint για την ανάκτηση του αριθμού φορτίσεων του οχήματος με ID "ΑΒ123456"
για το μήνα Νοέμβριο 2020 είναι το
https://localhost:8765/evcharge/api/SessionsPerEV/AB123456/20201101/20201130
Όλα τα αποτελέσματα που επιστρέφει το API θα είναι ταξινομημένα ως προς το πεδίο χρόνου που
περιέχουν (ώρα έναρξης, όπου υπάρχει και ώρα λήξης) με αύξουσα τάξη.

Μορφότυποι δεδομένων
Το REST API θα υποστηρίζει τον μορφότυπο JSON (content-type: application/json) και τον μορφότυπο CSV
(content-type: text/csv). Η επιλογή του μορφότυπου θα καθορίζεται στην αίτηση ως εξής (query
parameter):
{baseURL}/{service}/{path-to-resource}?format={json|csv}


Αν η παράμετρος format δεν παρέχεται σε κάποια αίτηση, να θεωρήσετε ότι το json θα είναι η default
τιμή. Σε κάθε περίπτωση η κωδικοποίηση χαρακτήρων (character encoding) θα πρέπει να είναι UTF8. Για
παράδειγμα, η προηγούμενη κλήση με αίτημα μορφότυπου δεδομένων "csv", έχει ως εξής:
https://localhost:8765/ evcharge/api/SessionsPerEV/AB123456/20201101/20201130&format=csv

Login & Logout
Το back-end σας θα υποστηρίζει δύο endpoints για το Login και το Logout των χρηστών. Ειδικότερα:
1. {baseURL}/login: Υποστηρίζει την μέθοδο POST και λαμβάνει τις παραμέτρους username,
password του χρήστη κωδικοποιημένους ως "application/x-www-form-urlencoded". Σε περίπτωση
επιτυχούς διαπίστευσης του χρήστη, επιστρέφει ένα json object με το token αυτού:
{"token":"FOO"}.
2. {baseURL}/logout: Υποστηρίζει τη μέθοδο POST και δε λαμβάνει παραμέτρους (ΠΡΟΣΟΧΗ: το
token του χρήστη που πρέπει να «αποσυνδεθεί» περιέχεται στον ειδικό γι’ αυτό το σκοπό custom
HTTP header, όπως αναφέρθηκε παραπάνω). Σε περίπτωση επιτυχίας, επιστρέφει μόνο το status
code 200 (empty response body).

Διαχειριστικά Endpoints
Το back-end σας θα υποστηρίζει τα παρακάτω endpoints, τα οποία θα είναι προσβάσιμα μόνο από τους
χρήστες – διαχειριστές του συστήματος:
1. {baseURL}/admin/usermod/:username/:password
Υποστηρίζει τη μέθοδο POST για την προσθήκη νέου χρήστη ή την αλλαγή password αν ο χρήστης
υπάρχει ήδη.
2. {baseURL}/admin/users/:username
Υποστηρίζει τη μέθοδο GET για την ανάγνωση των στοιχείων του συγκεκριμένου χρήστη.
3. {baseURL}/admin/system/sessionsupd
Υποστηρίζει τη μέθοδο POST για το «ανέβασμα» αρχείου CSV με δεδομένα γεγονότων φόρτισης.
Το αρχείο πρέπει να είναι κωδικοποιημένο ως πεδίο "file" σε multipart/form-data κωδικοποίηση.
Η κλήση αυτή θα αντικαθιστά την αυτόματη μεταφόρτωση δεδομένων από τα σημεία φόρτισης.
Ως αποτέλεσμα θα επιστρέφεται ένα json object με τρία αριθμητικά πεδία:
SessionsInUploadedFile, SessionsImported, TotalSessionsInDatabase.


Πρόσθετα (βοηθητικά) Endpoints
Τέλος, το back-end σας θα υποστηρίζει τα παρακάτω endpoints, τα οποία θα λειτουργήσουν επικουρικά
για τον πλήρως αυτοματοποιημένο έλεγχο που θα γίνει κατά την εξέταση της εργασίας:
1. {baseURL}/admin/healthcheck: Υποστηρίζει τη μέθοδο GET και επιβεβαιώνει την πλήρη
συνδεσιμότητα (end-to-end connectivity) μεταξύ του χρήστη και της βάσης δεδομένων. Το backend,
δηλαδή, θα πρέπει να ελέγξει τη συνδεσιμότητα με τη ΒΔ για να απαντήσει στο αίτημα. Σε
περίπτωση επιτυχούς σύνδεσης επιστρέφεται το json object: {"status":"OK"}, διαφορετικά
επιστρέφεται {"status":"failed"}.
2. {baseURL}/admin/resetsessions: Υποστηρίζει τη μέθοδο POST και προβαίνει σε αρχικοποίηση του
πίνακα γεγονότων φόρτισης (διαγραφή όλων των γεγονότων φόρτισης), καθώς και αρχικοποίηση
του default διαχειριστικού λογαριασμού (username: admin, password: petrol4ever). Σε περίπτωση
επιτυχίας, επιστρέφεται το json object: {"status":"OK"}, διαφορετικά επιστρέφεται
{"status":"failed"}.


2a. {baseURL}/SessionsPerPoint/:pointID/:yyyymmdd_from/:yyyymmdd_to
2b. {baseURL}/SessionsPerStation/:stationID/:yyyymmdd_from/:yyyymmdd_to
2c. {baseURL}/SessionsPerEV/:vehicleID/:yyyymmdd_from/:yyyymmdd_to
2d. {baseURL}/SessionsPerProvider/:providerID/:yyyymmdd_from/:yyyymmdd_to


2a. {baseURL}/SessionsPerPoint/:pointID/:yyyymmdd_from/:yyyymmdd_to
Επιστρέφεται λίστα με την ανάλυση των γεγονότων φόρτισης (sessions) για ένα σημείο και περίοδο που
δίνονται ως παράμετροι στη διεύθυνση του URL. Η παράσταση ημερομηνιών που επιστρέφονται πρέπει
να είναι της μορφής "YYYY-MM-DD HH:MM:SS"
Πεδίο Τύπος Περιγραφή
Point String Το μοναδικό ID του σημείου
PointOperator String Ο διαχειριστής του σημείου
RequestTimestamp String Η ημερομηνία/ώρα κλήσης
PeriodFrom String Η αιτούμενη περίοδος (από)
PeriodTo String Η αιτούμενη περίοδος (έως)
NumberOfChargingSessions Integer Ο αριθμός γεγονότων φόρτισης στην περίοδο
ChargingSessionsList: List (Πρέπει να περιλαμβάνει
[NumberOfChargingSessions] στοιχεία)
SessionIndex Integer Α/Α γεγονότος φόρτισης στην περίοδο (1, 2, 3, ...)
SessionID String Το ID του γεγονότος φόρτισης
StartedOn String Η χρονική στιγμή εκκίνησης της φόρτισης
FinishedOn String Η χρονική στιγμή ολοκλήρωσης της φόρτισης
Protocol String Το ακολουθούμενο πρωτόκολλο φόρτισης
EnergyDelivered Float Η ενέργεια που μεταφέρθηκε σε KWh
Payment String Ο τρόπος πληρωμής
VehicleType String Ο τύπος του οχήματος


2b. {baseURL}/SessionsPerStation/:stationID/:yyyymmdd_from/:yyyymmdd_to
Επιστρέφεται λίστα με την ομαδοποίηση ανά σημείο των γεγονότων φόρτισης για ένα σταθμό και περίοδο
που δίνονται ως παράμετροι στη διεύθυνση του URL. Για κάθε σημείο επιστρέφεται ο αριθμός των
γεγονότων και η ενέργεια που διατέθηκε. Η παράσταση ημερομηνιών που επιστρέφονται πρέπει να είναι
της μορφής "YYYY-MM-DD HH:MM:SS"

StationID String Το μοναδικό ID του σταθμού
Operator String Ο διαχειριστής του σταθμού
RequestTimestamp String Η ημερομηνία/ώρα κλήσης
PeriodFrom String Η αιτούμενη περίοδος (από)
PeriodTo String Η αιτούμενη περίοδος (έως)
TotalEnergyDelivered Float Η συνολική ενέργεια που διατέθηκε από το σταθμό
NumberOfChargingSessions Integer Ο αριθμός γεγονότων φόρτισης στην περίοδο
NumberOfActivePoints Integer Ο αριθμός των σημείων που χρησιμοποιήθηκαν
SessionsSummaryList: List (Πρέπει να περιλαμβάνει [NumberOfActivePoints]
στοιχεία)
PointID String Το μοναδικό ID του σημείου
PointSessions Integer Ο αριθμός φορτίσεων στο σημείο
EnergyDelivered Float Η συνολική ενέργεια που διατέθηκε από το σημείο

2c. {baseURL}/SessionsPerEV/:vehicleID/:yyyymmdd_from/:yyyymmdd_to
Επιστρέφεται λίστα με την ανάλυση των γεγονότων φόρτισης (sessions) για ένα όχημα και περίοδο που
δίνονται ως παράμετροι στη διεύθυνση του URL. Η παράσταση ημερομηνιών που επιστρέφονται πρέπει
να είναι της μορφής "YYYY-MM-DD HH:MM:SS"


VehicleID String Το μοναδικό ID του οχήματος
RequestTimestamp String Η ημερομηνία/ώρα κλήσης
PeriodFrom String Η αιτούμενη περίοδος (από)

PeriodTo String Η αιτούμενη περίοδος (έως)
TotalEnergyConsumed Float Η συνολική ενέργεια που φόρτισε το όχημα
NumberOfVisitedPoints Integer Ο αριθμός των σημείων που χρησιμοποιήθηκαν
NumberOfVehicleChargingSessions Integer Ο αριθμός φορτίσεων του οχήματος στην περίοδο
VehicleChargingSessionsList: List (πρέπει να περιλαμβάνει
[NumberOfVehicleChargingSessions] στοιχεία)
SessionIndex Integer Α/Α γεγονότος φόρτισης (1, 2, 3, ...) στην περίοδο
SessionID String Το ID του γεγονότος φόρτισης
EnergyProvider String Το όνομα του παρόχου ηλεκτρικής ενέργειας
StartedOn String Η χρονική στιγμή εκκίνησης της φόρτισης
FinishedOn String Η χρονική στιγμή ολοκλήρωσης της φόρτισης
ΕnergyDelivered Float Η ενέργεια που διατέθηκε σε αυτή τη φόρτιση
PricePolicyRef String Ο τιμοκατάλογος που εφαρμόστηκε
CostPerKWh Float Το κόστος ανά KWh
SessionCost Float Το συνολικό κόστος

2d. {baseURL}/SessionsPerProvider/:providerID/:yyyymmdd_from/:yyyymmdd_to
Επιστρέφεται λίστα με την ανάλυση των γεγονότων φόρτισης (sessions) για έναν πάροχο ηλεκτρικής
ενέργειας και περίοδο που δίνονται ως παράμετροι στη διεύθυνση του URL. Η παράσταση ημερομηνιών
που επιστρέφονται πρέπει να είναι της μορφής "YYYY-MM-DD HH:MM:SS"

ProviderID String Το ID του παρόχου ηλεκτρικής ενέργειας
ProviderName String Το όνομα του παρόχου ηλεκτρικής ενέργειας
StationID String Το μοναδικό ID του σταθμού
SessionID Integer Το ID του γεγονότος φόρτισης
VehicleID String Το μοναδικό ID του οχήματος
StartedOn String Η χρονική στιγμή εκκίνησης της φόρτισης
FinishedOn String Η χρονική στιγμή ολοκλήρωσης της φόρτισης
EnergyDelivered Float Η συνολική ενέργεια που διατέθηκε από το σημείο
PricePolicyRef String Ο τιμοκατάλογος που εφαρμόστηκε
CostPerKWh Float Το κόστος ανά KWh
TotalCost Float Το συνολικό κόστος



{
  "phases": 3,
  "serialNumber": "22345678-ABB",
  "brand": "ABB",
  "longitude": 22.923807,
  "latitude": 40.655061,
  "maxPower": 150,
  "ports": "",
  "pricePolicyRef": "150",
  "stationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "costPerKWh": 1.8
}

