<template>
  <router-view />
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
body {
  margin: 0;
}
:root {
  --happyPaw1: #e6bcb2;
  --happyPaw2: #de9281;
  --happyPaw3: #59371d;
  --happyPaw4: #8f542e;
  --darkGrey: #dddddd;
  --lightGrey: #eeeeee;
}
h1 {
  color: var(--happyPaw3);
}
h2,
h3 {
  color: var(--happyPaw4);
}
@media (min-width: 375px) {
  .text-md {
    font-size: 1.1rem;
  }
}
@media (min-width: 768px) {
  .text-md {
    font-size: 1.4rem;
  }
  .text-sm,
  address {
    font-size: 1.25rem;
  }
}
.error {
  font-size: 14px;
  color: red;
}
</style>
