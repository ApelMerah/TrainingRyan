<template>
    <div>
        <h1>Hello World!!!</h1>
        <p>
            {{company}}
        </p>
        <p>
            <button @click="onClick">
                {{n}}
            </button>
        </p>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component';
import { MyApp } from '../rest-api/lib/myApp';

    @Component({
        props: ['company']
    })
    export default class Calvin extends Vue {
        company: string;
        n: number = 0;

        async onClick() {
            this.n++;
            var api = new MyApp({
                baseUri: 'http://localhost:56632'
            });

            let response2 = await api.post({
                username: 'gloria',
                password: 'asdf'
            });
            console.log(response2.body);

            let response = await api.get();
            console.log(response);
        }
    }
</script>