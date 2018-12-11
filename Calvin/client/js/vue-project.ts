import Vue from 'vue';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import VeeValidate from 'vee-validate';
import Hello from './components/Hello.vue';
import Calvin from './components/Calvin.vue';

Vue.use(VeeValidate, {
    classes: true
});

Vue.component('fa', FontAwesomeIcon);

// components must be registered BEFORE the app root declaration
Vue.component('hello', Hello);
Vue.component('calvin', Calvin);

// bootstrap the Vue app from the root element <div id="app"></div>
new Vue().$mount('#app');
