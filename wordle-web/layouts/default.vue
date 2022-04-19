<!-- Work needed on this page
Add a settings dialog ❌✅
Add a settings selection to the App Bar's menu with a gear icon. This should open this dialog regardless of where you are on the site ❌✅
Option for dark and light mode ❌✅
Develop two additional color schemes (with creative names) and allow the user to change to them. Schemes should look good in both light and dark mode ❌✅
The above two items must be implemented with built in Veutify features ❌✅
-->

<template>
  <v-app dark>
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      :clipped="clipped"
      fixed
      app
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <!--
      <v-btn icon @click.stop="miniVariant = !miniVariant">
        <v-icon>mdi-{{ `chevron-${miniVariant ? 'right' : 'left'}` }}</v-icon>
      </v-btn>
      -->
      <!--
      <v-btn icon @click.stop="clipped = !clipped">
        <v-icon>mdi-application</v-icon>
      </v-btn>
      -->
      
      <v-toolbar-title v-text="title" />
      
      <v-spacer />

      <v-btn icon on-hover="light mode" @click.stop="fixed = !fixed" >
        <v-icon> mdi-brightness-5 </v-icon>
      </v-btn>

      </v-btn>
      <v-btn icon on-hover="dark mode" @click.stop="fixed = !fixed">
        <v-icon> mdi-brightness-2 </v-icon>
      </v-btn>

      <v-btn icon @click.native.stop="dialog = true">
        <v-icon> mdi-cog </v-icon>
      </v-btn>

      <v-btn icon @click.stop="rightDrawer = !rightDrawer">
        <v-icon>mdi-menu</v-icon>
      </v-btn>
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-navigation-drawer v-model="rightDrawer" :right="right" temporary fixed>
      <v-list>
        <v-list-item @click.native="right = !right">
          <v-list-item-action>
            <v-icon light> mdi-repeat </v-icon>
          </v-list-item-action>
          <v-list-item-title>Switch drawer (click me)</v-list-item-title>
        </v-list-item>


        <v-list-item :key="i" link @click="$router.push({ path: item.route })">
          <v-list-item-action>
            <v-icon light> mdi-trademark </v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>
              About
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>


      </v-list>
    </v-navigation-drawer>
    <v-footer :absolute="!fixed" app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  data() {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Welcome',
          to: '/',
        },
        {
          icon: 'mdi-chart-bubble',
          title: 'Inspire',
          to: '/inspire',
        },
        {
          icon: 'mdi-gamepad-variant',
          title: 'Wordle',
          to: '/game',
        },
        {
          icon: 'mdi-trademark', 
          title: 'About', 
          to: '/about',
        },
      ],
/*
      item: [
        {
          icon: 'mdi-trademark', 
          title: 'About', 
          to: '/about',
        }
      ],
*/
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'Ben Burbank & Hewr Tarkhany',
    }
  },
}
</script>
