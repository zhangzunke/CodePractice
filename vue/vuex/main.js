const store = new Vuex.Store({
  state: {
    count: 0
  },
  mutations: {
    increment (state){
      state.count ++
    },
    decrement(state){
      state.count --
    }
  }
})


new Vue({
    el: "#app",
    // state
    data () {
      return {
        count1: 0
      }
    },
    computed: {
      count() {
        return store.state.count
      }
    },
    // view
    template: `
      <div>{{ count }} 
      <button @click='increment'>Increment</button>
      <button @click='decrement'>Decrement</button>
      </div>
    `,
    // actions
    methods: {
      increment () {
        store.commit('increment')
      },
      decrement () {
        store.commit('decrement')
      }
    }
  })