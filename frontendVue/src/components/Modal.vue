<template>
  <div class="modal-backdrop" @click.self="declineProposition">
    <div class="custom-modal">
      <a href="#" class="custom-close" @click="declineProposition"></a>
      <h1>{{ header }}</h1>
      <p>{{ text }}</p>
      <button class="btn submit-btn w-25 m-2" @click="acceptProposition">
        {{ acceptPropositionText }}
      </button>
      <button class="btn submit-btn w-25 m-2" @click="declineProposition">
        {{ declinePropositionText }}
      </button>
    </div>
  </div>
</template>

<script>
export default {
  props: ["header", "text", "acceptPropositionText", "declinePropositionText"],
  methods: {
    declineProposition() {
      this.$emit("close");
    },
    acceptProposition() {
      this.$emit("accept");
    },
  },
};
</script>

<style>
.custom-modal {
  width: 600px;
  background: white;
  border-radius: 10px;
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
  padding: 60px;
}

.modal-backdrop {
  top: 0;
  position: fixed;
  background: rgba(0, 0, 0, 0.3);
  width: 100%;
  height: 100%;
}

.modal h1 {
  color: #03cfb4;
  border: none;
  padding: 0;
}

.custom-close {
  position: absolute;
  right: 32px;
  top: 32px;
  width: 32px;
  height: 32px;
  opacity: 0.3;
}
.custom-close:hover {
  opacity: 1;
}
.custom-close:before,
.custom-close:after {
  position: absolute;
  left: 15px;
  content: " ";
  height: 33px;
  width: 2px;
  background-color: #333;
}
.custom-close:before {
  transform: rotate(45deg);
}
.custom-close:after {
  transform: rotate(-45deg);
}
</style>