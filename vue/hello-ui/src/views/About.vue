<template>
  <div class="about">
    <h1>This is an about page</h1>
    {{msg}}
  </div>
</template>
<script>
import store from '@/store'
export default {
  data () {
    return {
      msg: store.state.count
    }
  }
}
</script>
