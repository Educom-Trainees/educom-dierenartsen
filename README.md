# Educom groepsopdracht Dierenartsen

Dit is een groepsopdracht van Edu-DetaCom om een reserveringen applicatie 
te maken voor 2 Dierenartsen, de [opdracht](./designs/Groepsopdracht%20Dierenartsen.pdf) en de [bijlagen](./designs/Groepsopdracht%20Dierenartsen%20Bijlagen.pdf) kan je doorlezen voor meer informatie. 

De applicatie bestaat uit een Frontend en en Backend. Voor de Frontend kan je kiezen tussen het Vue Frontend en het React Frontend. Voor de Backend werd er eerst ontwikkeld met de JsonServer backend, maar tegenwoordig met het ASP.NET Backend.

Hieronder staat hoe deze te starten


# Frontend
## Vue Frontend:
### Project setup
```
cd frontendVue
npm install
```

### Compiles and hot-reloads for development
```
cd frontendVue
npm run serve
```

### Compiles and minifies for production
```
cd frontendVue
npm run build
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).

## React Frontend
### Project setup
```
cd frontendReact
npm install
```

### Compiles and hot-reloads for development
```
cd frontendReact
npm run serve
```

### Compiles and minifies for production
```
cd frontendReact
npm run build
```

# Backend
## JSON Server Backend:
### Project setup
om de backend server te installeren: 
```bash
npm install -g json-server
```

### Start 
om de backend server te starten: 
```bash
json-server --watch ./backend/db.json
```
Zorg dat in `frontendVue/src/utils/api.js` staat `localhost:3000` !!  

## ASP.NET Backend
Dit is een ASP.NET WebAPI programma. Het [Database design](./BackendASP/Designs/mermaiderd.md) staat hier en de API Documentatie [hier](./BackendASP/Designs/api.html)

### Project setup
Create Mysql User met naam "PetCareUser" and the secret password

```ps
cd backendAsp
dotnet build
dotnet ef database update
```

### Start 
om de backend server te starten: 
```ps
cd backendAsp
dotnet run
```
