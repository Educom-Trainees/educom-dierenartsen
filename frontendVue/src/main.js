import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import { logoutUser } from './composables/accountManager'


axios.defaults.withCredentials = true;

axios.interceptors.response.use(
  async (response) => {
    return response;
  },
  async (error) => {
    if (error.response && error.response.status === 401) {
      await logoutUser();
      router.push('/login');
      alert('U bent uitgelogd omdat uw sessie is verlopen.');
    }

    return Promise.reject(error);
  }
);
createApp(App).use(router).mount('#app')



