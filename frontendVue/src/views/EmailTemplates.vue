<template>
    <div>
      <TopNavigation />
      <div id="emailtemplates-page" class="container-fluid d-flex p-3">
        <div class="d-flex flex-column w-100">
            <h1 class="text-lg text-left m-0 pt-0">Email Templates</h1>
            <div class="d-flex p-0">
                <div id="templates" class="d-flex flex-column">

                    <div class="list-group">
                          <a 
                            v-for="emailTemplate in emailTemplates" 
                            :key="emailTemplate.id" href="#" 
                            class="list-group-item list-group-item-action custom-list-item" 
                            :class="{ 'active': emailTemplate.isActive }"
                            @click="selectEmailTemplate(emailTemplate)">
                            {{ emailTemplate.templateName }}
                          </a>
                    </div>
                    <div class="tag-picker d-flex flex-column bg-secondary-subtle">
                      <p class="fw-bold pb-0 p-3">Variabele Invoervelden:</p>
                      <div class="d-flex flex-wrap p-3 pt-0">
                        <template v-for="(label, index) in ['Naam klant', 'Telefoonnummer', 'Email', 'Datum', 'Tijdslot', 'Duur', 'Dierenarts']" :key="index">
                          <button class="tag-button" @click="updateInput(label)" :disabled="isButtonDisabled(label)">{{ label }}</button>
                        </template>
                      </div>
                    </div>
                 
                </div>
                <div id="email" class="d-flex flex-grow-1 bg-secondary-subtle">
                    <form @submit.prevent="saveEmailTemplate" class="p-3 w-100">
                        <div class="d-flex flex-row row m-0">
                            <div class="mb-2 w-100">
                                <label for="templateName" class="form-label ms-1">Template Naam:</label>
                                <input v-model="selectedEmailTemplate.templateName" type="text" class="form-control m-0 bg-light" id="templateName">
                            </div>
                            <div class="mb-2 w-100">
                                <label for="subject" class="form-label ms-1">Onderwerp:</label>
                                <input v-model="selectedEmailTemplate.subject" type="text" class="form-control m-0 bg-light" id="subject" @focus="handleFocus">
                            </div>
                            <div class="mb-2">
                                <label for="body" class="form-label">Body:</label>
                                <textarea v-model="selectedEmailTemplate.body" class="form-control bg-light" id="body" style="height: 450px;" @focus="handleFocus"></textarea>
                            </div>
                        </div>
                        <button type="submit" class="btn submit-btn m-3">Opslaan</button>
                    </form>
                </div>
            </div>
        </div>
      </div>
      
    </div>
</template>
  
  
<script>
import TopNavigation from "../components/TopNavigation.vue";
import { getEmailTemplates, updateEmailTemplate } from "../composables/emailManager.js";

export default {
  name: "EmailTemplates",
  components: {
    TopNavigation,
  },
  async created() {
    const emailTemplates = await getEmailTemplates();
    this.emailTemplates = emailTemplates;
    console.log(emailTemplates);
  },
  data() {
    return {
      lastActiveField: null,
      emailTemplates: [],
      selectedEmailTemplate: {
        subject: "",
        body: "",
        emailType: "",
      },
    };
  },
  methods: {
    handleFocus(event) {
      this.lastActiveField = event.target.id;
    },
    isButtonDisabled(tag) {
      return this.selectedEmailTemplate.emailType === 0 && ['Tijdslot', 'Datum', 'Duur', 'Dierenarts'].includes(tag);
    },
    updateInput(value) {
      const inputFieldId = this.lastActiveField;
      const textarea = document.getElementById(inputFieldId);

      if (textarea) {
        const selectionStart = textarea.selectionStart;
        const selectionEnd = textarea.selectionEnd;
        const textBefore = this.selectedEmailTemplate[inputFieldId].slice(0, selectionStart);
        const textAfter = this.selectedEmailTemplate[inputFieldId].slice(selectionEnd);

        this.selectedEmailTemplate[inputFieldId] = textBefore + value + textAfter;

        const newPosition = selectionStart + value.length;

        setTimeout(() => {
          textarea.selectionStart = newPosition;
          textarea.selectionEnd = newPosition;
          textarea.focus();
        }, 0);
      }
    },
    selectEmailTemplate(emailTemplate) {
      this.emailTemplates.forEach(template => {
        template.isActive = (template.id === emailTemplate.id);
      });

      this.selectedEmailTemplate = {
        id: emailTemplate.id,
        templateName: emailTemplate.templateName, 
        subject: emailTemplate.subject,
        body: emailTemplate.body,
        emailType: emailTemplate.emailType,
      };
    },
    async saveEmailTemplate() {
      const updatedEmailTemplate = this.selectedEmailTemplate;

      await updateEmailTemplate(updatedEmailTemplate)
      this.emailTemplates = await getEmailTemplates();
      this.selectEmailTemplate(this.selectedEmailTemplate);

    }

  },
};
</script>

<style>
  .list-group-item.custom-list-item {
    border-radius: 0 !important;
    background-color: #eeeeee;
  }

  .list-group {
    min-width: 225px;
    flex-shrink: 0;
  }

  .tag-picker {
    max-width: 225px;
  }

  .form-control {
    text-align: left;
    padding-left: 10px;
    border-radius: 0;
  }

  #templates .list-group-item.custom-list-item.active {
    background-color: #e2e3e5;
    color: #2c3e50;
    font-weight: bold;
    border: none;
    border-bottom: 2px solid #2c3e50;
  }

  .submit-btn {
    width: 20%;
  }

  .tag-button {
    margin-right: 15px;
    padding: 5px 15px;
    font-weight: bold;
    color: var(--happyPaw4);
  }

  .tag-button:disabled {
    color: grey;
    cursor: not-allowed;
  }

  .tag-button:not(:disabled):hover {
    color: #2c3e50;
    cursor: pointer;
  }
</style>
