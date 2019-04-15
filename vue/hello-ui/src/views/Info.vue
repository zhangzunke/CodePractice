<template>
    <div>
        Hello Info Component
        <button @click="add()">Add</button>
    </div>
</template>
<script>
import store from '@/store'
export default {
  name: 'Info',
  store,
  methods: {
    add () {
      console.log('test')
      store.commit('increase')
    }
  }
}
</script>
<style scoped>

</style>
