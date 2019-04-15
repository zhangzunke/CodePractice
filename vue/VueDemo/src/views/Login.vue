<template>
    <div>
      <form action="">
        User Name <input type="text">
        Password <input type="text">
        <button @click="login()">Loin</button>
        <button>Register</button>
      </form>
    </div>
</template>

<script>
export default {
  name: 'login',
  methods: {
    login () {
      this.$router.push('/home/list')
    }
  }
}
</script>
