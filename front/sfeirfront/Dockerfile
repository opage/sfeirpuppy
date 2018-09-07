FROM node:8-alpine as builder
WORKDIR /front

COPY package.json package-lock.json ./
RUN npm set progress=false && npm config set depth 0 && npm cache clean --force
## Storing node modules on a separate layer will prevent unnecessary npm installs at each build
RUN npm i 

COPY . ./
RUN npm run build


FROM nginx:1.13.3-alpine
WORKDIR /front

## Copy our default nginx config
COPY nginx/default.conf /etc/nginx/conf.d/
## Remove default nginx website
RUN rm -rf /usr/share/nginx/html/*
## From 'builder' stage copy over the artifacts in dist folder to default nginx public folder
COPY --from=builder /front/build/ /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]
