<template>
    <div class="row justify-content-center align-items-center register-row mb-4">
        <div class="col-sm-3 col-md-5 col-10 change-area">
            <h2 class="usertitle">Mijn Huisdieren</h2>
            <div class="row">
                <div class="col-sm-5 result">
                    <p>type</p>
                </div>
                <div class="col-sm-5 result">
                    <p>naam</p>
                </div>
                <div class="col-sm-2 result">
                    <button type="submit">-</button>
                </div>
            </div>
            <button @click.prevent="changeInput()" v-if="!showInput" class="btn submit-btn mt-1">Huisdier toevoegen</button>
            <form v-if="showInput" @submit.prevent="registerPet" id="register-form" class="d-flex flex-column align-items-center mt-4">
                <select required v-model="type_pet">
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
                <button type="submit" class="btn submit-btn mt-4">Opslaan</button>
            </form>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            showInput: false,
            type_pet: '',
            petname: ''
        }
    },
    methods: {
        registerPet(){
            console.log(this.type_pet)
            console.log(this.petname)
            this.showInput = !this.showInput
        },
        changeInput(){
            this.showInput = !this.showInput
        }
    }
}
</script>

<style>

</style>