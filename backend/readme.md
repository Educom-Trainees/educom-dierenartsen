## Gebruik API:

### First time install 
om de backend server te installeren: 
```bash
npm install -g json-server
```

### Start 
om de backend server te starten: 
```bash
json-server --watch ./backend/db.json
```

### Constants
`preference` can be 
 - 0 for `no-preference`, 
 - 1 for `karel lant` or 
 - 2 for `danique de beer`
  
`doctor` can be 
 - 1 for `karel lant` or 
 - 2 for `danique de beer` or 
 - 3 for both
    
`status` can be 
 - 0 for `planned`, 
 - 1 for `canceled by doctor` or 
 - 2 for `canceled by customer` 

### API
De volgende API calls zijn mogelijk
|Command|URL|Description|
|---|---|---|
| GET   | http://localhost:3000/pet-types                              | list of all possible pet types |
| GET   | http://localhost:3000/timeslots?date=2023-11-10              | list of all possible timeslots on the 10th of November |
| GET   | http://localhost:3000/appointments?status=0&date=2023-11-10  | to get all 'planned' appointments of the 10th of November |
| GET   | http://localhost:3000/appointments/1122                      | to get the appointment with id 1122 |
| GET   | http://localhost:3000/appointments?status=2                   | to get all appointments that have been cancelled by the customer
| POST  | http://localhost:3000/appointments                            | add an new appointment |
