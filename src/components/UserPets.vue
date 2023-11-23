<template>
    <div class="row justify-content-center align-items-center register-row mb-4">
        <div class="col-sm-3 col-md-5 col-10 change-area">
            <h2 class="usertitle">Mijn Huisdieren</h2>
            <div class="row" v-for="pet in pets" :key="pet.id">
                <div class="col-sm-5 result">
                    <p v-if="pet.type == 1">Hond</p>
                    <p v-if="pet.type == 2">Kat</p>
                    <p v-if="pet.type == 3">Konijn</p>
                    <p v-if="pet.type == 4">Cavia</p>
                    <p v-if="pet.type == 5">Hamster</p>
                    <p v-if="pet.type == 6">Rat</p>
                    <p v-if="pet.type == 7">Muis</p>
                    <p v-if="pet.type == 8">Kleine hond</p>
                    <p v-if="pet.type == 9">Grote hond</p>
                </div>
                <div class="col-sm-5 result">
                    <p>{{ pet.name}}</p>
                </div>
                <!-- <div class="col-sm-2 result">
                    <button type="submit">-</button>
                </div> -->
            </div>
            <button @click.prevent="changeInput()" v-if="!showInput" class="btn submit-btn mt-1">Huisdier toevoegen</button>
            <form v-if="showInput" @submit.prevent="registerPet" id="register-form" class="d-flex flex-column align-items-center mt-4">
                <div>
                <select required v-model="type_pet" class="type_select">
                    <option hidden value="">Type dier*</option>
                    <option value="2">kat</option>
                    <option value="3">konijn</option>
                    <option value="4">cavia</option>
                    <option value="5">hamster</option>
                    <option value="6">rat</option>
                    <option value="7">muis</option>
                    <option value="8">kleine hond</option>
                    <option value="9">grote hond</option>
                </select>
                <input required v-model="petname" type="text" placeholder="naam*">
                </div>
                <button type="submit" class="btn submit-btn mt-4">Opslaan</button>
            </form>
        </div>
    </div>
</template>

<script>
import { addPet } from '../composables/userChanges.js'
import { getUserById } from '../composables/userManager.js'
import { getUserDataFromSession } from '../composables/sessionManager.js'
export default {
    data() {
        return {
            pets: [],
            showInput: false,
            type_pet: '',
            petname: ''
        }
    },
    async created() {
        await this.readyPage()
    },
    methods: {
        async registerPet(){
            await addPet(this.type_pet, this.petname)
            this.showInput = !this.showInput
            this.pets = []
            await this.readyPage()
        },
        changeInput(){
            this.showInput = !this.showInput
        },
        async readyPage(){
            const user = getUserDataFromSession()
            var userdata = getUserById(user.userId)

            const length = await userdata.then(function(result) {
                if(result[0].pets){
                    var length = result[0].pets.length
                    return {length}
                }else {
                    return 0
                }
            })

            for (let i = 0; i < length.length; i++) {
                const value = await userdata.then(function(result) {
                    var id = result[0].pets[i].id
                    var type = result[0].pets[i].type
                    var name = result[0].pets[i].name
                    return {id, type, name}
                })
                this.pets.push(value)
            }
        }
    }
}
</script>

<style>
.type_select{
    margin-right: 80px;
}
</style>