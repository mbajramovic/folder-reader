# Folder Reader

## Getting Started

### Prerequisites

```
Node.js (npm)
```

To install Node/NPM, download the package file from https://nodejs.org/en/download/ and install it.

### Project Structure

Project is divided into REST and UI (frontend) part. REST part is implemented with Node and Express and UI part with Ember.
Each part is in separate project in this repository.

### Starting the Application

First, clone this repository to your computer:

```
git clone 
```

To start REST service navigate to `folder-reader-rest` and execute the following commands:

```
npm install
npm run dev
```

Now, the rest service should be started on http://localhost:9000.

To start UI part od application navigate to `folder-reader-frontend` and execute the following command:

```
npm install
ember serve --proxy http://localhost:9000
```

Open http://localhost:4200 in your favourite browser.
