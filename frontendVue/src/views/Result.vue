<template>
  <div>
  <TopNavigation />
    <h1 class="appointment_header">Afspraak maken</h1>
    <div class="test">
      <h2><img src="/balk4.png" /></h2>
      <Suspense>
        <template #default>
          <ResultSuspense :id="id"/>
        </template>
        <template #fallback>
          <p>Loading...</p>
        </template>
      </Suspense>

    </div>
  </div>
</template>

<script>
import ResultSuspense from "@/components/ResultSuspense.vue";
import TopNavigation from "../components/TopNavigation.vue";

export default {
  name: "Result",
  components: {
    TopNavigation,
    ResultSuspense,
  },
  props: ["id"],
};
</script>

<style>
</style>