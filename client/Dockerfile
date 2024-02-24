# Stage 1: Build the Vue.js application
FROM node:14 as build-stage

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

# Stage 2: Serve the application with Express
FROM node:14 as production-stage

WORKDIR /app

COPY --from=build-stage /app/dist ./dist

RUN npm install express connect-history-api-fallback

COPY server.js .

EXPOSE 8080

CMD [ "node", "server.js" ]
