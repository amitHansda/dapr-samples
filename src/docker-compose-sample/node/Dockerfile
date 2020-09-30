FROM node:8-alpine
WORKDIR /app
COPY app.js app.js
COPY package.json package.json
RUN npm install
EXPOSE 3000
CMD [ "node", "app.js" ]