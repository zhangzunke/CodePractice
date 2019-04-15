<template>
    <div>
        Title : <input type="text" v-model="title">
        Content : <input type="text" v-model="content">
        <button @click="add()">Add</button>
    </div>
</template>

<script>
import store from '@/store'
export default {
  name: 'add',
  store,
  data () {
    return {
      title: '',
      content: ''
    }
  },
  methods: {
    add () {
      store.commit('addItem', {
        title: this.title,
        content: this.content
      })
      this.title = ''
      this.content = ''
      this.$router.push('/home/list')
    }
  }
}
</script>
